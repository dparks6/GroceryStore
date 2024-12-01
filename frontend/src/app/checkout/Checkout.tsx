import { FlipWords } from '@/components/ui/FlipWords'
import Link from 'next/link'
import React from 'react'

const CheckoutPage = () => {
  var fullname = 'Loading...';
  return (
    <form className='bg-white outline p-5 w-[30rem] h-full flex flex-col rounded-xl'>
      <div className='flex flex-col items-center w-full'>
      <h1 className='absolute left-28'><Link href="/" className="text-blue-500 font-bold">Back to Shopping</Link></h1>
        <h1 className='mt-10 text-2xl font-bold mb-2'>Checkout<FlipWords words={["Fast", "Secure", "Easy" ]}/></h1>
      </div>
        <div className='flex flex-col items-center'>
          <div className='mr-7'>
          <span className='font-bold'>Full Name:</span><span className='ml-2'>{fullname || 'Loading...'}</span>
          </div>
          <div>
          <span className='font-bold'>Email Address:</span><span className='ml-2'>{fullname || 'Loading...'}</span>
          </div>
          <div className='ml-2'>
          <span className='font-bold'>Phone Number:</span><span className='ml-2'>{fullname || 'Loading...'}</span>
          </div>
          <div className='mr-12 mb-5'>
          <span className='font-bold'>Address:</span><span className='ml-2'>{fullname || 'Loading...'}</span>
          </div>
        </div>
        <div className=' flex flex-col items-center'>
          <div className='mr-12 mb-40'>
            <span className='font-bold mr-5'>Shopping Cart: </span><span className='ml-2'></span>
          </div>
          <div className='mr-12'>
          <span className='font-bold mr-12 mb-3'>Item Count: </span><span className='ml-2'></span>
          </div>
          <div className='mb-4 mr-2'>
          <span className='font-bold mr-20'>Amount Due:</span><span className='ml-2'></span>
          </div>
          <div className='ml-2'>
          <input className='outline p-2 rounded-xl w-[12rem] mb-6 mr-3' placeholder='Credit Card Number' type="numerical" maxLength={16} required/>
          </div>
          <div className='mr-12'>
          <input className='outline p-2 rounded-xl w-[12rem] mb-5 ml-10' placeholder='Security Code' type="password" maxLength={3} required/>
          </div>
          <div>
            <button className='rounded-3xl font-bold bg-emerald-400 w-32 p-2'>Pay</button>
          </div>
        </div>
    </form>
  )
}

export default CheckoutPage