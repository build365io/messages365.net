import Link from 'next/link'
import React from 'react'
import Logo from './Logo'
import LoginButton from './LoginButton'
import { getCurrentUser } from '../actions/authActions'
import UserActions from './UserActions'

export default async function Navbar() {
  const user = await getCurrentUser();
  
  return (
    <header className='
      sticky top-0 z-50 bg-white p-5 items-center text-gray-800 shadow-md
    '>
      <div className='max-w-screen-2xl mx-auto flex justify-between'>
        <Logo />

        {user ? (
          <UserActions user={user} />
        ) : (
          <LoginButton />
        )}        
      </div>
    </header>
  )
}
