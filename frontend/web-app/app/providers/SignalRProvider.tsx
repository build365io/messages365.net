'use client'

import { Post } from '@/types';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { User } from 'next-auth';
import React, { ReactNode, useEffect, useState } from 'react'
import { toast } from 'react-hot-toast';

type Props = {
    children: ReactNode
    user: User | null
}

export default function SignalRProvider({ children, user }: Props) {
    const [connection, setConnection] = useState<HubConnection | null>(null);
    const apiUrl = process.env.NODE_ENV === 'production' 
        ? 'https://api.messages365.com/notifications'
        : process.env.NEXT_PUBLIC_NOTIFY_URL

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl(apiUrl!)
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, [apiUrl]);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected to notification hub');

                    connection.on('PostCreated', (post: Post) => {
                        if (user?.username == post.author) {
                            return toast(<h5>PostCreated{post.id}</h5>, 
                                {duration: 10000})
                        }
                    });
                }).catch(error => console.log(error));
        }

        return () => {
            connection?.stop();
        }
    }, [connection])

    return (
        children
    )
}