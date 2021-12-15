import React from "react";
import * as shortUrlService from "./services/shortUrlService";
import { toast } from "react-toastify";
class ShortUrl extends React.Component {
  state = { url: "" };

  onFormFieldChanged = (e) => {
    let currentTarget = e.currentTarget;
    let newValue = currentTarget.value;
    let inputName = currentTarget.name;
    console.log(e);
    console.log(currentTarget);
    this.setState(() => {
      let newState = {};
      newState[inputName] = newValue;
      console.log(newValue);

      return newState;
    });
  };
  handleSubmit = (e) => {
    e.preventDefault();
    console.log("buttonCLicked");
    let url = this.state;
    shortUrlService
      .get(url)
      .then(this.onCreateSuccess)
      .catch(this.OnCreateError);
  };

  onCreateSuccess = (response) => {
    console.log(response.data.item);
    toast(response.data.item, "success");
  };
  OnCreateError = (response) => {
    console.warn({ error: response });
    toast("error");
  };

  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-4 -md-4 p-5">
            <label htmlFor="URL">URL</label>
            <input
              type="text"
              className="form-control"
              onChange={this.onFormFieldChanged}
            ></input>
            <button
              type="submit"
              className="btn btn-dark"
              onClick={this.handleSubmit}
            >
              Submit
            </button>
          </div>
        </div>
      </div>
    );
  }
}
export default ShortUrl;
