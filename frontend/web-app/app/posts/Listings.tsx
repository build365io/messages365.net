'use client'

import { useParamsStore } from "@/hooks/useParamsStore";
import { PagedResult, Post } from "@/types";
import Link from "next/link";
import { useState, useEffect } from "react";
import { shallow } from "zustand/shallow";
import { getData } from '../actions/postActions';
import PostForm2 from "../posts2/PostForm2";
import PostImage from "./PostImage";
import qs from 'query-string';

export default function Listings() {
    const [data, setData] = useState<PagedResult<Post>>()
    const url = qs.stringifyUrl({ url: '', query: {}})

    useEffect(() => {
        getData(url).then(data => {
            setData(data);
        })
    }, [url])
    
    if (!data) return <h3>Loading...</h3>
    
    return (
        <div>
            <div className="-ml-3">
                <PostForm2 />
            </div>
            
            <div>
                {data && data.results.map((post) => (
                    <div className='flex mt-12' key={post.id}>
                        <div className='flex justify-center mt-4 border-l border-gray-300'>
                            <img className="absolute h-14 w-14 rounded-full" src="https://images.unsplash.com/photo-1491528323818-fdd1faba62cc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="" />
                        </div>
                        <div className="bg-white ml-12 mb-5 mt-2">
                            <div>{post.author}</div>
                            <h5 className="mb-2 text-lg font-semibold tracking-tight">Noteworthy technology acquisitions 2021</h5>
                            <div className="mb-3 text-sm">{post.content?.slice(0, 81)}{post.content?.length > 81 && <Link href={`/posts/details/${post.id}`} className='group'><p className='text-blue-500'>Read more...</p>
                            </Link>}</div>
                            <a href="#">
                                <PostImage imageUrl={post.imageUrl}/>
                            </a>
                            <img className="absolute h-8 w-8 rounded-full" src="https://images.unsplash.com/photo-1491528323818-fdd1faba62cc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80" alt="" />
                        </div>
                    </div>
                ))}
            </div>
        </div>
    )
}
