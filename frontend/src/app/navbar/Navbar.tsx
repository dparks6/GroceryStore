import React from 'react'
import Link from 'next/link'
import { IoIosSearch } from "react-icons/io";
import { FaShoppingCart } from "react-icons/fa";
import { CgProfile } from "react-icons/cg";

const Navbar = () => {
  return (
    <div className='flex flex-row outline outline-1 py-4 font-bold'>
        <Link href="/" className='px-5 mr-10'>
          <span>Shop</span>
          <span className='text-emerald-400'>Quick</span>
        </Link>
        <div className='relative flex flex-row items-center mr-40'>
          <div className='relative w-[30em]'>
            <IoIosSearch className='absolute top-1/2 right-4 transform -translate-y-1/2 text-gray-500'/>
            <input className=' outline outline-1 rounded-xl w-full pl-1' type="text" placeholder='  Search...'></input>
          </div>
        </div>
        <Link href="/cart" className='flex flex-col items-center'>
          <FaShoppingCart/>
          <span className='text-bold px-30'>Cart</span>
        </Link>
        <Link href="/profile" className='flex flex-col items-center px-10'>
          <CgProfile />
          <span className='text-bold'>Profile</span>
        </Link>
    </div>
  )
}

export default Navbar