
var Router = ReactRouter.Router;
var Route = ReactRouter.Route;
var browserHistory = ReactRouter.browserHistory;

ReactDOM.render(
         <Router history={browserHistory}>
                 <Route path="/" component={Login} />
                 <Route path="users(/:id(/:level))" component={Users} />
                 <Route path="main(/:pageOfUserId)" component={Main} />                 
                 <Route path="login" component={Login} />
                 <Route path="register" component={Register} />
         </Router>,
         document.getElementById("container")
) 