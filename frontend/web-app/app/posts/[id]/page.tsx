import React from 'react'
import PostImage from '../PostImage';

export async function getData(id: string) {
  const res = await fetch(`http://localhost:7001/api/posts/${id}`);

  if (!res.ok) throw new Error('Failed to fetch data');

  return res.json();
}

export default async function Details({ params }: { params: { id: string } }) {
   const data = await getData(params.id);

  return (
    <div className='top-36'>
      <PostImage imageUrl={data.imageUrl}/>
      <div className='mt-8 max-w-xl'>{data.content}</div>
    </div>
  )
}
