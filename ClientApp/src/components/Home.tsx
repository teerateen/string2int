import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => {
  const [textNumber, SetTextNumber] = React.useState("");
  const [CheckedNumber, SetCheckedNumber] = React.useState("");

  const FnTextCheck = () => {
    fetch(`Str2Int/String2Int/${textNumber}`)
      .then(response => response.json() as Promise<string>)
      .then(data => {
        SetCheckedNumber("Result: " + data);
      });
  }
  return (
    <React.Fragment>
      <h1>string2int Challenge</h1>
      <div className="input-group col-6">
        <input type="text" className="form-control" placeholder="input text"
          onChange={(e) => {
            SetTextNumber(e.target.value)
          }} />
        <button className="btn btn-primary" type="button" onClick={FnTextCheck}>Check Int!!</button>
        <button className="btn btn-outline" >{CheckedNumber}</button>
      </div>
    </React.Fragment>)
}


export default connect()(Home);
