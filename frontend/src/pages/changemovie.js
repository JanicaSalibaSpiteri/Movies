import React from "react";
import {
  PlayIcon,
  StarIcon,
  ClockIcon,
  DocumentTextIcon,
  LinkIcon,
} from "@heroicons/react/outline";
import axios from "axios";
import { CONTEXT } from "../shared/path";
import genreslist from "./genres";

export default class Movie extends React.Component {
  state = {
    movies: [],
    name: "",
    length: "",
    description: "",
    genres: [],
    image: "",
  };

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value });
  };

  handleSubmit = (event) => {
    var currentPath = window.location.pathname.toLowerCase();
    event.preventDefault();

    var genresArray = getCheckedBoxes("checkbox");

    if (currentPath === "/createmovie") {
      axios
        .post(CONTEXT + "/api/movie/", {
          name: this.state.name,
          description: this.state.description,
          genres: genresArray,
          rating: parseFloat(this.state.rating),
          length: this.state.length,
          image: this.state.image,
        })
        .then((res) => {
          window.location.href = "/allmovies?name=" + this.state.name;
        });
    } else if (currentPath === "/editmovie") {
      axios
        .put(
          CONTEXT +
            "/api/movie/" +
            new URLSearchParams(this.props.location.search.toLowerCase()).get(
              "id"
            ),
          {
            name: this.state.name,
            description: this.state.description,
            genres: genresArray,
            rating: parseFloat(this.state.rating),
            length: this.state.length,
            image: this.state.image,
          }
        )
        .then((res) => {
          window.location.href = "/allmovies?name=" + this.state.name;
        });
    }
  };

  componentDidMount() {
    const Search = this.props.location.search.toLowerCase();
    const Id = new URLSearchParams(Search).get("id");

    if (Id == "") {
      window.location.href = "/createmovie";
    }

    if (Id != undefined) {
      axios
        .get(CONTEXT + "/api/movie/" + Id, {
          responseType: "json",
        })
        .then((res) => {
          this.setState({ movies: res.data });
          this.setState({ name: res.data.name });
          this.setState({ description: res.data.description });
          this.setState({ rating: res.data.rating });
          this.setState({ length: res.data.length });
          this.setState({ image: res.data.image });
        });
    }
  }

  render() {
    return (
      <div class="px-4 py-6 sm:px-0">
        <main>
          <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
            {CreateEditMovie(
              this.state.movies,
              this.handleSubmit,
              this.handleChange
            )}
          </div>
        </main>
      </div>
    );
  }
}

function CreateEditMovie(data, submit, change) {
  var currentPath = window.location.pathname.toLowerCase();
  if (currentPath === "/createmovie") {
    return CreateMovie(submit, change);
  } else if (currentPath === "/editmovie") {
    if (data == null) {
      window.location.href = "/?error=InvalidRequest";
    } else {
      return EditMovie(data, submit, change);
    }
  }
}

function CreateMovie(submit, change) {
  return (
    <form onSubmit={submit}>
      <div class="relative">
        <PlayIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="Movie Name"
          placeholder="Movie Name"
          name="name"
          minlength="2"
          required
          onChange={change}
        />
      </div>

      <div class="relative mt-2">
        <StarIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="number"
          aria-label="Rating"
          placeholder="Rating"
          name="rating"
          min="0"
          max="10"
          step=".1"
          required
          onChange={change}
        />
      </div>

      <div class="relative mt-2">
        <ClockIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="Length"
          placeholder="Length (Valid format example: 1hr 05mins)"
          name="length"
          pattern="[0-9]{1}hr [0-9]{2}mins"
          required
          onChange={change}
        />
      </div>

      <div class="relative mt-2">
        <DocumentTextIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <textarea
          id="description"
          name="description"
          rows="3"
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          placeholder="Description"
          name="description"
          onChange={change}
        ></textarea>
      </div>

      <div class="relative mt-2">
        <LinkIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="URL"
          placeholder="Picture URL"
          name="image"
          onChange={change}
        />
      </div>

      <div class="relative mt-2">
        <label class="block text-sm text-left font-medium text-gray-700">
          Movie Genres
        </label>
        {genreslist.map((item) => (
          <div class="flex items-start">
            <div class="flex items-center h-5">
              <input
                id={"chk" + item.name}
                name="checkbox"
                type="checkbox"
                class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
              />
            </div>
            <div class="ml-3 text-sm text-left">
              <label for={"chk" + item.name} class="font-bold text-gray-700">
                {item.name}
              </label>
            </div>
          </div>
        ))}
      </div>
      <div class="flex items-center justify-center my-4">
        <button
          type="submit"
          className="inline-flex py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          Save
        </button>
      </div>
    </form>
  );
}

function EditMovie(data, submit, change) {
  return (
    <form onSubmit={submit}>
      <div class="relative">
        <PlayIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="Movie Name"
          placeholder="Movie Name"
          name="name"
          defaultValue={data.name}
          onChange={change}
          minlength="2"
          required
        />
      </div>

      <div class="relative mt-2">
        <StarIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="number"
          aria-label="Rating"
          placeholder="Rating"
          name="rating"
          defaultValue={data.rating}
          onChange={change}
          min="0"
          max="10"
          step=".1"
          required
        />
      </div>

      <div class="relative mt-2">
        <ClockIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="Length"
          placeholder="Length (Valid format example: 1hr 05mins)"
          name="length"
          Value={data.length}
          onChange={change}
          pattern="[0-9]{1}hr [0-9]{2}mins"
          required
        />
      </div>

      <div class="relative mt-2">
        <DocumentTextIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <textarea
          id="description"
          name="description"
          rows="3"
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          placeholder="Description"
          name="description"
          defaultValue={data.description}
          onChange={change}
        ></textarea>
      </div>

      <div class="relative mt-2">
        <LinkIcon
          className="h-8 w-8"
          aria-hidden="true"
          width="20"
          height="20"
          class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
        />
        <input
          class="focus:border-light-blue-500 focus:ring-1 focus:ring-light-blue-500 focus:outline-none w-full text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          type="text"
          aria-label="URL"
          placeholder="Picture URL"
          name="image"
          defaultValue={data.image}
          onChange={change}
        />
      </div>

      <div class="relative mt-2">
        <label class="block text-sm text-left font-medium text-gray-700">
          Movie Genres
        </label>
        {genreslist.map((item) => (
          <div class="flex items-start">
            <div class="flex items-center h-5">
              <input
                id={"chk" + item.name}
                name="checkbox"
                type="checkbox"
                class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                Checked={genresChecked(data.genres, item.name)}
              />
            </div>
            <div class="ml-3 text-sm text-left">
              <label for={"chk" + item.name} class="font-bold text-gray-700">
                {item.name}
              </label>
            </div>
          </div>
        ))}
      </div>
      <div class="flex items-center justify-center my-4">
        <button
          type="submit"
          className="inline-flex py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          Update
        </button>
      </div>
    </form>
  );
}

function genresChecked(genres, loopitem) {
  var array = (genres + "").split(",");
  for (var i = 0; i < array.length; i++) {
    {
      if (array[i].toLowerCase() == loopitem.toLowerCase()) {
        return "checked";
      }
    }
  }
}

function getCheckedBoxes(chkboxName) {
  var checkboxes = document.getElementsByName(chkboxName);
  var checkboxesChecked = [];
  // loop over them all
  for (var i = 0; i < checkboxes.length; i++) {
    // And stick the checked ones onto an array...
    if (checkboxes[i].checked) {
      checkboxesChecked.push(checkboxes[i].id.replace("chk", ""));
    }
  }
  // Return the array if it is non-empty, or null

  return checkboxesChecked.length > 0 ? checkboxesChecked : null;
}
