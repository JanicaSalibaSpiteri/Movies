/* This example requires Tailwind CSS v2.0+ */
import NavigationBar from "./layout/NavigationBar";
import Footer from "./layout/Footer";
import { Route } from "react-router-dom";
import allmovies from "./pages/allmovies";
import movie from "./pages/movie";
import modifymovie from "./pages/changemovie";
import home from "./pages/home";

import "./App.css";

function App() {
  return (
    <div className="App" class="flex flex-col h-screen justify-between">
      <NavigationBar />
      <div class="mb-auto">
        <Route exact path="/" component={home} />
        <Route exact path="/allmovies" component={allmovies} />
        <Route exact path="/movie" component={movie} />
        <Route exact path="/createmovie" component={modifymovie} />
        <Route exact path="/editmovie" component={modifymovie} />
      </div>
      <Footer />
    </div>
  );
}

export default App;
