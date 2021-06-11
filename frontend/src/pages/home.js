import React from "react";
import { BrowserRouter as Router, Link } from "react-router-dom";
import axios from "axios";
import { CONTEXT } from "../shared/path";

export default class Homepage extends React.Component {
  state = {
    movies: [],
  };
  componentDidMount() {
    axios
      .get(CONTEXT + "/api/movie/gettop5/", {
        responseType: "json",
      })
      .then((res) => {
        const movies = res.data;
        this.setState({ movies });
      });
  }

  render() {
    return (
      <Router>
        <main>
          <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
            <div class="flex flex-wrap flex--movie">
              {this.state.movies.map((item) => (
                <div class="w-full lg:w-1/6 rounded-xl overflow-hidden shadow-lg m-4 bg-gray-800">
                  <img class="w-full" src={item.image} alt={item.name} />

                  <div class="px-4 py-2">
                    <h3 class="text-white pt-2 pb-2">{item.name}</h3>
                    <div class="button-container flex justify-center mb-2">
                      <a
                        href={"movie?id=" + item.id}
                        class="focus:outline-none py-2 px-2 rounded-md text-sm text-white bg-red-500"
                        type="button"
                      >
                        More Info
                      </a>
                      <a
                        href={"editmovie?id=" + item.id}
                        class="focus:outline-none py-2 ml-2 px-2 rounded-md text-sm text-white bg-green-700"
                        type="button"
                      >
                        Edit movie
                      </a>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </main>
      </Router>
    );
  }
}
