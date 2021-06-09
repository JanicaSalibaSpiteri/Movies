import { HeartIcon } from "@heroicons/react/outline";

function Footer() {
  return (
    <footer class="bg-gray-800 w-full py-4 px-4 block">
      <div class="flex items-center justify-center my-4">
        <p class="inline-flex text-white px-2 pt-2">
          Built with{" "}
          <HeartIcon
            className="w-5 h-5 mx-1 pt-px text-red-600"
            aria-hidden="true"
          />{" "}
          by Janica Saliba Spiteri.
        </p>
      </div>
    </footer>
  );
}

export default Footer;
