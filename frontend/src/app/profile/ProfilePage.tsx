import { FlipWords } from '@/components/ui/FlipWords'
import Link from 'next/link'
import React from 'react'

const ProfilePage = () => {
  var fullname = 'Loading...';
  var email = 'Loading...';
  var number = 'Loading...';
  var address = 'Loading...';
  var dateJoined = 'Loading...';
  var pastPurchases = 'Loading...';
  return (
    <div className='bg-white shadow-md p-5 w-[30rem] h-full flex flex-col rounded-xl'>
      <div className='flex flex-col items-center w-full'>
      <h1 className='absolute left-28'><Link href="/" className="text-blue-500 font-bold">Back to Shopping</Link></h1>
        <h1 className='mt-10 text-2xl font-bold mb-2'>Welcome<FlipWords words={["Loyal", "Valued", "Home" ]}/>Customer</h1>
      </div>
        <div className='flex flex-col items-center mr-12'>
          <div className='mr-7'>
          <span className='font-bold'>Full Name:</span><span className='ml-2'>{fullname || 'Loading...'}</span>
          </div>
          <div className='mr-4'>
          <span className='font-bold'>Date Joined:</span><span className='ml-2'>{dateJoined || 'Loading...'}</span>
          </div>
          <div>
          <span className='font-bold'>Email Address:</span><span className='ml-2'>{email || 'Loading...'}</span>
          </div>
          <div className='ml-2'>
          <span className='font-bold'>Phone Number:</span><span className='ml-2'>{number || 'Loading...'}</span>
          </div>
          <div className='mr-12'>
          <span className='font-bold'>Address:</span><span className='ml-2'>{address || 'Loading...'}</span>
          </div>
          <div className='mb-8'>
          <span className='font-bold'>Past Purchases:</span><span className='ml-2'>{pastPurchases || 'Loading...'}</span>
          </div>
        </div>
    </div>
  )
}

export default ProfilePage