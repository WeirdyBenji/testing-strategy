import { Component } from "react";
import { sha256 }    from 'js-sha256';
import './Login.css';

class Login extends Component {
  constructor() {
    super();
    this.state = {
      email: '',
      password: '',
    };

    this.handleUser   = this.handleUser.bind(this);
    this.handlePasswd = this.handlePasswd.bind(this);
    this.login        = this.login.bind(this);
  }

  login() {
    let data = {...this.state};

    data.password = sha256.update(data.password).toString();
    fetch('https://localhost:5001/api/login', {
      method: "POST",
      body: data
    });
  }

  handlePasswd(event) {
    this.setState({password: event.target.value});
  }

  handleUser(event) {
    this.setState({email: event.target.value});
  }

  render() {
    return (
      <div>
        <h1>Login</h1>
        <form onSubmit={this.login}>
          <p>Username: <input type="text" value={this.state.email} onChange={this.handleUser} /></p>
          <p>Password: <input type="password" value={this.state.password} onChange={this.handlePasswd} /></p>
          <button type="submit" value="Submit" >Log in</button>
        </form>
      </div>
    );
  }
}

export default Login;