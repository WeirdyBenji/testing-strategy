import { Component } from "react";
import { sha256 }    from 'js-sha256';

import './Register.css';

class Register extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      name: '',
      password: '',
      confirm: ''
    };

    this.handleUser      = this.handleUser.bind(this);
    this.handlePasswd    = this.handlePasswd.bind(this);
    this.handleConfirm   = this.handleConfirm.bind(this);
    this.handleEmail     = this.handleEmail.bind(this);
    this.register        = this.register.bind(this);
  }

  register() {
    if (this.state.password !== this.state.confirm) {
      alert("Confirm and password are different");
      return;
    }
    let data = {...this.state};

    data.password = sha256.update(data.password).toString();
    fetch('/register', {
      method: "POST",
      body: data
    });
  }

  handlePasswd(event) {
    this.setState({password: event.target.value});
  }

  handleConfirm(event) {
    this.setState({confrim: event.target.value});
  }

  handleEmail(event) {
    this.setState({email: event.target.value});
  }

  handleUser(event) {
    this.setState({name: event.target.value});
  }

  render() {
    return (
      <div>
        <h1>Register</h1>
        <form onSubmit={this.register}>
          <p>Email: <input type="email" value={this.state.email} onChange={this.handleEmail} /></p>
          <p>Username: <input type="text" value={this.state.name} onChange={this.handleUser} /></p>
          <p>Password: <input type="password" value={this.state.password} onChange={this.handlePasswd} /></p>
          <p>Confirm: <input type="password" value={this.state.confirm} onChange={this.handleConfirm} /></p>
          <button type="submit" value="Submit" >Register</button>
        </form>
      </div>
    );
  }
}

export default Register;