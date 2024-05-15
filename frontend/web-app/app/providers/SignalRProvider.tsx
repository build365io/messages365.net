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
    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('http://localhost:6001/notifications')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected to notification hub');

                    connection.on('PostCreated', (post: Post) => {
                        if (user?.username !== post.author) {
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