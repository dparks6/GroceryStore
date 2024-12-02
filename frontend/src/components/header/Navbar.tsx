import React from "react";
import Link from "next/link";
import { IoIosSearch } from "react-icons/io";
import { FaShoppingCart } from "react-icons/fa";
import { CgProfile } from "react-icons/cg";

const Navbar = () => {
  return (
    <div className="fixed top-0 left-0 right-0 z-50 flex flex-row justify-between items-center outline outline-1 outline-zinc-300 py-4 font-bold bg-white">
      <div className="flex flex-row">
        <Link href="/" className="px-5 mr-10">
          <span>Shop</span>
          <span className="text-emerald-400">Quik</span>
        </Link>
        <div className="relative flex flex-row items-center mr-40">
          <div className="relative w-[30em]">
            <IoIosSearch className="absolute top-1/2 right-4 transform -translate-y-1/2 text-gray-500" />
            <input
              className="text-sm outline outline-1 rounded-xl w-full px-2 py-1"
              type="text"
              placeholder="Search..."
            ></input>
          </div>
        </div>
      </div>
      <div className="flex flex-row">
        <Link href="/cart" className="flex flex-col items-center">
          <FaShoppingCart />
          <span className="text-bold px-30">Cart</span>
        </Link>
        <Link href="/profile" className="flex flex-col items-center px-10">
          <CgProfile />
          <span className="text-bold">Profile</span>
        </Link>
      </div>
    </div>
  );
};

export default Navbar;
