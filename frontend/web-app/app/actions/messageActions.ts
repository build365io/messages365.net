'use server'

import { fetchWrapper } from "@/lib/fetchWrapper"
import { Message, PagedResult, Post } from "@/types"
import { FieldValues } from "react-hook-form"

export async function getData(): Promise<Message[]> {
    const res = await fetch(`http://localhost:6001/messages`);

    if (!res.ok) throw new Error('Failed to fetch data')

    return res.json();
}

export async function createMessage(data: FieldValues) {
    return await fetchWrapper.post('messages', data);
}
