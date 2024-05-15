'use client'

import { useParamsStore } from "@/hooks/useParamsStore";
import { PagedResult, Post } from "@/types";
import Link from "next/link";
import { useState, useEffect } from "react";
import { shallow } from "zustand/shallow";
import { getData } from '../actions/postActions';
import AppPagination from "../components/AppPagination";
import Filters from "./Filters";
import PostImage from "./PostImage";
import qs from 'query-string';
import EmptyFilter from "../components/EmptyFilter";

export default function Listings() {
    const [data, setData] = useState<PagedResult<Post>>();
    const params = useParamsStore(state => ({
        pageNumber: state.pageNumber,
        pageSize: state.pageSize,
        searchTerm: state.searchTerm,
        orderBy: state.orderBy,
        filterBy: state.filterBy
    }), shallow)
    const setParams = useParamsStore(state => state.setParams);
    const url = qs.stringifyUrl({ url: '', query: params })

    function setPageNumber(pageNumber: number) {
        setParams({ pageNumber })
    }

    useEffect(() => {
        getData(url).then(data => {
            setData(data);
        })
    }, [url])

    if (!data) return <h3>Loading...</h3>
    
    return (
        <>
            <Filters />
            {data.totalCount === 0 ? (
            <EmptyFilter showReset />
            ) : (
                <>
                    <div className='grid grid-cols-4 gap-6'>
                        {data && data.results.map((post) => (                    
                            <div className="border rounded-lg shadow-xl mb-5 h-fit overflow-hidden" key={post.id}>
                                <div className='aspect-w-15 aspect-h-10'>
                                    <PostImage imageUrl={post.imageUrl}/>
                                </div>
                                <div className="p-5">
                                    <div>{post.author}</div>
                                    <div className="mb-3 text-sm">{post.content?.slice(0, 81)}{post.content?.length > 81 && <Link href={`/posts/${post.id}`} className='group'><p className='text-blue-500'>Read more...</p>
                                    </Link>}</div>
                                </div>
                            </div>
                        ))}
                    </div>

                    <div className='flex justify-center mt-4'>
                        <AppPagination pageChanged={setPageNumber}
                            currentPage={params.pageNumber} pageCount={data.pageCount} />
                    </div>
                </>
            )}
        </>
    )
}
