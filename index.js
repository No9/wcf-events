var announce = require('socket.io-announce').createClient();
var actions = [];
var simpleaction = {};
process.setMaxListeners(0);
// Select a node by its class name. You can also select by tag e.g. 'div'
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