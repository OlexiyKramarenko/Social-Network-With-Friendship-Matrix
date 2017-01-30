
 
var Login = React.createClass({

    getDefaultProps: function () {
        return {
            url: '/account/login',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
        };
    }, 
    login: function () {
        var json = JSON.stringify({ UserName: $('#name').val(), Password: $('#pwd').val() }) 
        $.ajax({
            url: this.props.url,
            type: this.props.type,
            contentType: this.props.contentType,
            data: json,
            success: function (data) {
                if (data.Succeded) { 
                    location = 'http://localhost:4000/main';
                }
            }.bind(this)
        }); 
    },

    render: function () {
        return (<div>
                <h3 id="login">Login</h3>
                <form className="form-horizontal ">
                    <div className="form-group">
                        <label className="control-label col-sm-2" for="email">Name:</label>
                        <div className="col-sm-10">
                            <input type="email" className="form-control" id="name" placeholder="Enter your name" />
                        </div>
                    </div>
                    <div className="form-group">
                        <label className="control-label col-sm-2" for="pwd">Password:</label>
                        <div className="col-sm-10">
                            <input type="password" className="form-control" id="pwd" placeholder="Enter password" />
                        </div>
                    </div>
                    <div className="form-group">
                        <div className="col-sm-offset-2 col-sm-10">
                            <button type="button" onClick={this.login} className="btn btn-default">Submit</button>
                        </div>
                    </div>
                </form>
        </div>)
    }
});
