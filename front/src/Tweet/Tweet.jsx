import "./Tweet.css";

export default function Tweet(props) {
  return (
    <div className="tweet">
      <h2>{props.name || 'Anonymous'}</h2>
      <p>{props.content || '...'}</p>
    </div>
  );
}