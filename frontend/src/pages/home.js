import React from "react";
import { BrowserRouter as Router, Link } from "react-router-dom";

// Params are placeholders in the URL that begin
// with a colon, like the `:id` param defined in
// the route in this example. A similar convention
// is used for matching dynamic segments in other
// popular web frameworks like Rails and Express.

export default function home() {
  return (
    <Router>
      <main>
        <div className="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
          {/* Replace with your content */}

          <div class="flex flex-wrap flex--movie">
            <div class="w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4">
              <img
                class="w-full"
                src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/lNkDYKmrVem1J0aAfCnQlJOCKnT.jpg"
                alt="A Quiet Place movie poster"
              />

              <div class="px-4 py-2 bg-gray-800">
                <h3 class="text-white text-2xl TenorSans-Regular_font__1MM39 pt-2 pb-2">
                  Halloween <span>(2018)</span>
                </h3>
                <div class="button-container flex justify-between mb-2">
                  <button
                    class="focus:outline-none py-2 px-2 rounded-md text-sm text-white bg-gray-500"
                    type="button"
                  >
                    More Info
                  </button>
                </div>
              </div>
            </div>
            <div class="w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4">
              <img
                class="w-full"
                src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/zQDqgzSdTGSDu4rDcQTq7TAttmy.jpg"
                alt="A Quiet Place movie poster"
              />

              <div class="px-4 py-2 bg-gray-800">
                <h3 class="font-bold text-xl mb-2 text-gray-200">
                  Climax <span>(2018)</span>
                </h3>
                <div class="button-container flex justify-between mb-2">
                  <button class="text-sm text-gray-200">More Info</button>
                  <button class="text-sm font-bold py-2 px-4 rounded bg-orange-400">
                    Add to List
                  </button>
                </div>
              </div>
            </div>
            <div class="w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4">
              <img
                class="w-full"
                src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/rd269f2Yftxxam3EOJPYVwrvjIJ.jpg"
                alt="A Quiet Place movie poster"
              />

              <div class="px-4 py-2 bg-gray-800">
                <h3 class="font-bold text-xl mb-2 text-gray-200">
                  Apostle <span>(2018)</span>
                </h3>
                <div class="button-container flex justify-between mb-2">
                  <button class="text-sm text-gray-200">More Info</button>
                  <button class="text-sm font-bold py-2 px-4 rounded bg-orange-400">
                    Add to List
                  </button>
                </div>
              </div>
            </div>
            <div class="w-full lg:w-1/5 rounded-xl overflow-hidden shadow-lg m-4">
              <img
                class="w-full"
                src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/wfLzocgEa7DDQAJWeorEiDFx9WM.jpg"
                alt="A Quiet Place movie poster"
              />

              <div class="px-4 py-2 bg-gray-800">
                <h3 class="font-bold text-xl mb-2 text-gray-200">
                  Slaughter <span>(2018)</span>
                </h3>
                <div class="button-container flex justify-between mb-2">
                  <button class="text-sm text-gray-200">More Info</button>
                  <button class="text-sm font-bold py-2 px-4 rounded bg-orange-400">
                    Add to List
                  </button>
                </div>
              </div>
            </div>
          </div>

          {/* /End replace */}
        </div>
      </main>
    </Router>
  );
}
