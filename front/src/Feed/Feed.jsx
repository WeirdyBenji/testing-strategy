import { Component } from "react";

import Tweet from "../Tweet/Tweet";
import "./Feed.css";

class Feed extends Component {
  constructor() {
    super();
    this.state = {
      tweets: []
    };
    this.getTweets = this.getTweets.bind(this);
    this.getTweets();
  }

  componentDidMount() {
    this.data = this.getTweets();
  }

  getTweets() {
    //this.setState({tweets: [
    //   {author: "Jacques", body: "Coucou"},
    //   {author: null, body: "Hello there"},
    //   {author: "Grivous", body: "GENERAL KENOBI"},
    //   {author: "Charles de Gaulle", body: "Je vous ai comrpis."}
    // ]});
    fetch("https://localhost:5001/api/twitz")
    .then(response => response.json())
    .then(data => {
      this.setState({tweets: data});
    });
  }

  render() {
    return (
      <div className="feed-page">
        <h1>Galilée</h1>
        {
          this.state.tweets.map(function(obj, i) {
            return <Tweet key={i} name={obj.author || 'Anonymous'} content={obj.body}/>
          })
        }
      </div>
    );
  }
}

export default Feed;