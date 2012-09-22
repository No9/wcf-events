var announce = require('socket.io-announce').createClient();
var cluster = require('cluster');
var numCPUs = require('os').cpus().length;
process.setMaxListeners(5000);

if (cluster.isMaster) {
  // Fork workers.
  for (var i = 0; i < numCPUs; i++) {
    cluster.fork();
  }

  cluster.on('exit', function(worker, code, signal) {
    console.log('worker ' + worker.process.pid + ' died');
  });
} else {// Select a node by its class name. You can also select by tag e.g. 'div'
	
	var actions = [];
	var simpleaction = {};
	simpleaction.query = 'GetDataResult';

	// Create an function that is executed when that node is selected. Here we just replace '& frames' with '+trumpet' 
	simpleaction.func = function (node) {
								node.html(function (html) {
									console.log(node.name + ' = ' + html);
									announce.emit( 'cdcevent', { "item" : html } );
									return;
								});
								return;
							};
						 
	// Add the action to the action array
	actions.push(simpleaction);

	var harmon = require('harmon').harmon(actions) 
	var proxyoptions = { router: 'table.json' };
	require('./lib/appproxy.js').generate(proxyoptions, harmon);
}


