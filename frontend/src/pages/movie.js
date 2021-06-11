import React, { Component } from "react";
import { StarIcon, ClockIcon } from "@heroicons/react/outline";
import axios from "axios";
import { CONTEXT } from "../shared/path";

export default class Movie extends React.Component {
  state = {
    movies: [],
  };
  componentDidMount() {
    const Search = this.props.location.search;
    const Id = new URLSearchParams(Search).get("id");
    if (Id == "") {
      window.location.href = "/?error=InvalidRequest";
    }
    axios
      .get(CONTEXT + "/api/movie/" + Id, {
        responseType: "json",
      })
      .then((res) => {
        if (res.data == null) {
          window.location.href = "/?error=InvalidRequest";
        } else {
          this.setState({ movies: res.data });
        }
      });
  }

  render() {
    return (
      <main>
        <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
          <div class="content">
            <div class="flex items-center justify-between w-full my-4 pl-4 sm:pr-4">
              <div class="mr-6">
                <h2 class="text-3xl md:text-4xl font-semibold tracking-tight leading-7 md:leading-10 mb-1 truncate pb-5">
                  {this.state.movies.name}
                </h2>
                <div class="font-base tracking-tight text-gray-600">
                  {this.state.movies.description}
                </div>
              </div>
            </div>

            <div>
              <div class="w-full">
                <div class="bg-white shadow-md  rounded-3xl p-4">
                  <div class="flex-none lg:flex">
                    <div class=" w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4">
                      <img
                        src={this.state.movies.image}
                        alt={this.state.movies.name}
                        class="w-full"
                      />
                    </div>
                    <div class="flex-auto ml-3 justify-evenly py-2">
                      <p class="mt-3"></p>
                      <div class="flex py-4  text-sm text-gray-600">
                        <div class="flex-1 inline-flex items-center">
                          <StarIcon
                            className="h-8 w-8"
                            aria-hidden="true"
                            width="20"
                            height="20"
                            class="h-5 w-5 mr-3"
                          />

                          <p class="">{this.state.movies.rating}</p>
                        </div>
                        <div class="flex-1 inline-flex items-center">
                          <ClockIcon
                            className="h-8 w-8"
                            aria-hidden="true"
                            width="20"
                            height="20"
                            class="h-5 w-5 mr-3"
                          />
                          <p class="">{this.state.movies.length}</p>
                        </div>
                      </div>
                      <div class="flex p-4 pb-2 border-t border-gray-200 "></div>
                      <div class="flex space-x-3 text-sm font-medium">
                        <div class="flex-auto flex space-x-3">
                          {genresSplitter(this.state.movies.genres).map(
                            (item) => (
                              <span class="mb-2 md:mb-0 bg-white px-5 py-2 shadow-sm tracking-wider border text-gray-600 rounded-full hover:bg-gray-100 inline-flex items-center space-x-2 ">
                                <span>{item}</span>
                              </span>
                            )
                          )}
                        </div>
                        <a
                          href={"editmovie?id=" + this.state.movies.id}
                          class="mb-2 md:mb-0 bg-gray-900 px-5 py-2 shadow-sm tracking-wider text-white rounded-full hover:bg-gray-800"
                          type="button"
                          aria-label="like"
                        >
                          Edit Movie
                        </a>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </main>
    );
  }
}

function genresSplitter(genres) {
  return (genres + "").split(",");
}
