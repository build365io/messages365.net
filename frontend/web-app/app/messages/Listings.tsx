'use client'

import React, { useEffect, useState } from 'react'
import { Message } from '@/types';
import { getData } from '../actions//messageActions';
import './messages.css'
import MessageForm from './MessageForm';

export default function Listings() {
    const [data, setData] = useState<Message[]>();
    
    useEffect(() => {
        getData().then(data => {
            setData(data);
        })
    }, [])

    if (!data) return <h3>Loading...</h3>
    
    return (
        <div>
            <div className='grid grid-cols-4 gap-6'>
                {data.map((message: Message) => (                
                    <div className="bg-yellow-100 rounded-lg shadow-xl mb-5 h-fit" key={message.id}>
                        <div className="p-5">
                            <h5 className="ooohBaby mb-2 tracking-tight text-gray-900 text-center">{message.content}</h5>

                            <h5 className="ooohBaby2 mb-2 tracking-tight text-gray-900 text-center">{message.author}</h5>

                            <h5 className="mb-2 tracking-tight text-gray-900">{message.createdAt}</h5>
                        </div>
                    </div>
                ))}
            </div>
            <MessageForm />
        </div>
    )
}
