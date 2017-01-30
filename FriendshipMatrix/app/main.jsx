

var Main = React.createClass({

    getInitialState: function () {
        return { avatar: null, username: null, btnText: null, addRemoveBtnCssClass: "invisible", action: null };
    },
    componentWillMount: function () {
        this.populateData();
        this.defineButton();
    },
    action: function () {
        if (this.state.action === "remove") {
            this.removeFromFriends();
            this.setState({ btnText: "You have got now 1 enemy." });
        }
        else {
            //this.sendFriendRequest();   //but I did that simpler:
            this.addToFriends();
            this.setState({ btnText: "Done. This human is your friend now." });
        }  
    }, 
    addToFriends: function () {
        $.ajax({
            url: '/users/AddToFriends?id=' + this.props.params.pageOfUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
            }.bind(this),
            error: function (a, b, c) {
            }.bind(this)
        });
    },
    sendFriendRequest: function () {
        $.ajax({
            url: '/users/SendFriendRequest?id=' + this.props.params.pageOfUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
            }.bind(this),
            error: function (a, b, c) {
            }.bind(this)
        });
    },
    removeFromFriends: function () {
        $.ajax({
            url: '/users/RemoveFromFriends?id=' + this.props.params.pageOfUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
            }.bind(this),
            error: function (a, b, c) {
            }.bind(this)
        });
    },
    showFriendsTree: function () {
        var level = $("#level option:selected").text(); 
        location.href = 'http://localhost:4000/users/' + this.props.params.pageOfUserId + "/" + level;
    },
    populateData: function () {
        $.ajax({
            url: '/home/GetUser?id=' + this.props.params.pageOfUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                this.setState({ avatar: data.userVM.Avatar });
                this.setState({ username: data.userVM.UserName });
            }.bind(this),
            error: function (a, b, c) { 
            }.bind(this)
        });
    },
    defineButton: function () {
        $.ajax({
            url: '/users/CurrentUserStatus?id=' + this.props.params.pageOfUserId,
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                switch(data.Role)
                { 
                    case ("friend"):
                        this.setState({ addRemoveBtnCssClass: "btn btn-default" });
                        this.setState({ btnText: "Remove from friends" });
                        this.setState({ action: "remove" });
                        break;

                    case ("unknown"):
                        this.setState({ addRemoveBtnCssClass: "btn btn-default" });
                        this.setState({ btnText: "Add to friends" });
                        this.setState({ action: "add" });
                        break;

                    case ("admin"):
                        this.setState({ addRemoveBtnCssClass: "invisible" });
                        break;
                } 
            }.bind(this),
            error: function (a, b, c) {
            }.bind(this)
        });
    },

    render: function () {
        return (<div>
                 <h3>{ this.state.username }</h3>
                 <img src={ this.state.avatar } />
            <button type="button" onClick={this.action} className={ this.state.addRemoveBtnCssClass }>{ this.state.btnText }</button>
            <br/>
    Level:
            <select id="level">
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
                <option>6</option>
                <option>7</option>
                <option>8</option>
                <option>9</option>
                <option>10</option>
                <option>11</option>
                <option>12</option>
                <option>13</option>
                <option>14</option>
            </select>&nbsp;&nbsp;&nbsp;&nbsp;
            <button type="button" onClick={this.showFriendsTree} className="">
                Show friends of this user by selected level
            </button>

        </div>);
    }
})
