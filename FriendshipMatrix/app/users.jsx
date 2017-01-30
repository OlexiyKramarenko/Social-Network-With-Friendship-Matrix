

var Row = React.createClass({

    render: function () {

        return (<tr>
                        <td><img src={this.props.Avatar} /></td>
                        <td><a href={'http://localhost:4000/main/' + this.props.UserID }>{this.props.UserName}</a></td>
                        <td>{this.props.UserID}</td>
        </tr>);
    }
});

var Users = React.createClass({

    componentDidMount: function () {
        this.populateData();
    },
    getInitialState: function () {
        return { users: [] };
    },
    populateData: function () {

        var url = '';
       
        if (this.props.params.id) {
            url = '/users/GetFriendsTree/';
            url += this.props.params.id;
            if (this.props.params.level)
                url +="/"+ this.props.params.level;
        }
        else
            url = '/users/getusers/';

        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                this.setState({ users: data.users });
            }.bind(this)
        });
    },
    render: function () {
 
        var rows = [];
        for (var i = 0; i < this.state.users.length; i++) {
            var item = this.state.users[i];
            rows.push(<Row Avatar={item.Avatar} UserName={item.UserName} UserID={item.ID } />)
        }
        return (
                      <table id="users">
                          <tbody>
                              {rows}
                          </tbody>
                      </table>
                    );
    }
});
