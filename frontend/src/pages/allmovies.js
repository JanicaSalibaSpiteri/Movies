import React from "react";
import movies from "./movies";
import { SearchIcon, FilterIcon } from "@heroicons/react/outline";

function allmovies() {
  return (
    <main>
      <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
        <form class="relative">
          <SearchIcon
            className="h-8 w-8"
            aria-hidden="true"
            width="20"
            height="20"
            class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
          />
          <input
            class="focus:border-light-blue-500 w-4/5 pr-20 mr-2 focus:ring-1 focus:ring-light-blue-500 focus:outline-none text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
            type="text"
            aria-label="Movie Name"
            placeholder="Movie Name"
            id="name"
            name="name"
          />
          <button
            type="submit"
            className="inline-flex w-1/6 py-2 px-4 border justify-center border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Search
          </button>
        </form>

        <form class="relative mt-2">
          <FilterIcon
            className="h-8 w-8"
            aria-hidden="true"
            width="20"
            height="20"
            class="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400"
          />
          <select
            id="genre"
            name="genre"
            autocomplete="genre"
            class="focus:border-light-blue-500 w-4/5 pr-20 mr-2 focus:ring-1 focus:ring-light-blue-500 focus:outline-none text-sm text-black placeholder-gray-500 border border-gray-200 rounded-md py-2 pl-10"
          >
            <option>Horror</option>
            <option>Thriller</option>
            <option>Action</option>
          </select>
          <button
            type="submit"
            className="inline-flex py-2 w-1/6 px-4 border justify-center border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Filter
          </button>
        </form>

        <div class="flex flex-wrap flex--movie">
          {movies.map((item, i) => (
            <div
              key={i}
              class="w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4 bg-gray-800"
            >
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
  );
}

export default allmovies;
