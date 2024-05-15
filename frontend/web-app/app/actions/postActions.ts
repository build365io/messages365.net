'use server'

import { fetchWrapper } from "@/lib/fetchWrapper"
import { PagedResult, Post } from "@/types"
import { FieldValues } from "react-hook-form"

export async function getData(query: string): Promise<PagedResult<Post>> {
    const res = await fetch(`http://localhost:6001/search${query}`);

    if (!res.ok) throw new Error('Failed to fetch data')

    return res.json();
}

export async function createPost(data: FieldValues) {
    return await fetchWrapper.post('posts', data);
}
