import { Component } from "react";
import './Register.css';

class Register extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: '',
      password: '',
    };

    this.handleUser      = this.handleUser.bind(this);
    this.handlePasswd    = this.handlePasswd.bind(this);
    this.register        = this.register.bind(this);
  }

  register() {
    console.log(this.state);
  }

  handlePasswd(event) {
    this.setState({password: event.target.value});
  }

  handleUser(event) {
    this.setState({user: event.target.value});
  }

  render() {
    return (
      <div>
        <h1>Register</h1>
        <form onSubmit={this.register}>
          <p>Username: <input type="text" value={this.state.user} onChange={this.handleUser} /></p>
          <p>Password: <input type="password" value={this.state.password} onChange={this.handlePasswd} /></p>
          <button type="submit" value="Submit" >Register</button>
        </form>
      </div>
    );
  }
}

export default Register;