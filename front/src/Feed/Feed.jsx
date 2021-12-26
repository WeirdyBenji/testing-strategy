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
    // this.setState({tweets: [
    //   {author: "Jacques", content: "Coucou"},
    //   {author: "Kenobi", content: "Hello there"},
    //   {author: "Grivous", content: "GENERAL KENOBI"},
    //   {author: "Charles de Gaulle", content: "Je vous ai comrpis."}
    // ]});
    fetch("/twits")
    .then((response) => {
      this.setState(this.state.tweets, response);
    });
  }

  render() {
    return (
      <div className="feed-page">
        <h1>Galiler</h1>
        {
          this.state.tweets.map(function(obj, i) {
            return <Tweet key={i} name={obj.author} content={obj.content}/>
          })
        }
      </div>
    );
  }
}

export default Feed;