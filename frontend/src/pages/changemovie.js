import React, { useState, useEffect } from "react";
import {
  PlayIcon,
  StarIcon,
  ClockIcon,
  DocumentTextIcon,
  LinkIcon,
} from "@heroicons/react/outline";

const Movie = ({ location }) => {
  const [ID, setID] = useState("");

  useEffect(() => {
    const params = new URLSearchParams(location.search);
    const id = params.get("id");
    setID(id ? id : 0);
  }, []);

  return <div>{CreateEditMovie(ID)}</div>;
};

function CreateEditMovie(ID) {
  if (ID == 0) {
    return CreateMovie();
  }
  return EditMovie(ID);
}

function CreateMovie() {
  return (
    <div class="px-4 py-6 sm:px-0">
      <main>
        <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
          {/* Replace with your content */}

          <form>
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
                type="text"
                aria-label="Rating"
                placeholder="Rating"
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
                placeholder="Length"
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
              />
            </div>

            <div class="relative mt-2">
              <label class="block text-sm text-left font-medium text-gray-700">
                Movie Genras
              </label>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="comments"
                    name="comments"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="comments" class="font-bold text-gray-700">
                    Horror
                  </label>
                </div>
              </div>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="candidates"
                    name="candidates"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="candidates" class="font-bold text-gray-700">
                    Thriller
                  </label>
                </div>
              </div>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="offers"
                    name="offers"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="offers" class="font-bold text-gray-700">
                    Action
                  </label>
                </div>
              </div>
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

          {/* /End replace */}
        </div>
      </main>
    </div>
  );
}

function EditMovie(ID) {
  return (
    <div class="px-4 py-6 sm:px-0">
      <main>
        <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
          {/* Replace with your content */}

          <form>
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
                value={ID}
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
                type="text"
                aria-label="Rating"
                placeholder="Rating"
                value={ID}
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
                placeholder="Length"
                value={ID}
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
                value={ID}
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
                value={ID}
              />
            </div>

            <div class="relative mt-2">
              <label class="block text-sm text-left font-medium text-gray-700">
                Movie Genras
              </label>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="comments"
                    name="comments"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                    value={ID}
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="comments" class="font-bold text-gray-700">
                    Horror
                  </label>
                </div>
              </div>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="candidates"
                    name="candidates"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="candidates" class="font-bold text-gray-700">
                    Thriller
                  </label>
                </div>
              </div>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="offers"
                    name="offers"
                    type="checkbox"
                    class="focus:ring-indigo-500 h-4 w-4 text-indigo-600 border-gray-300 rounded"
                  />
                </div>
                <div class="ml-3 text-sm text-left">
                  <label for="offers" class="font-bold text-gray-700">
                    Action
                  </label>
                </div>
              </div>
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

          {/* /End replace */}
        </div>
      </main>
    </div>
  );
}

export default Movie;
