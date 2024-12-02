import { FlipWords } from "@/components/ui/FlipWords";
import Link from "next/link";

const CartPage = () => {
  return (
    <div className="bg-white flex felx col items-center w-[30rem] rounded shadow-md">
      <div className="flex flex-col items-center w-full">
        <h1 className="absolute left-28">
          <Link href="/" className="text-blue-500 font-bold">
            Back to Shopping
          </Link>
        </h1>
        <h1 className="mt-10 text-2xl font-bold mb-2">
          Cart it
          <FlipWords words={["Quick", "Fresh", "Clean"]} />
        </h1>
        <div className=" flex flex-col items-center mr-12">
          <div className="mr-12 mb-80">
            <span className="font-bold mr-5">Shopping Cart: </span>
            <span className="ml-2"></span>
          </div>
          <div className="mr-12">
            <span className="font-bold mr-12 mb-3">Item Count: </span>
            <span className="ml-2"></span>
          </div>
          <div className="mb-4 mr-2">
            <span className="font-bold mr-20">Amount Due:</span>
            <span className="ml-2"></span>
          </div>
          <div>
            <a href="/checkout">
              <button className="rounded-3xl font-bold bg-emerald-400 w-32 p-2 mb-6">
                Checkout
              </button>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartPage;
