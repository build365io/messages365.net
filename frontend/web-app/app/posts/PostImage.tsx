'use client'

import React, { useState } from 'react'
import Image from 'next/image'

type Props = {
    imageUrl: string
}

export default function PostImage({imageUrl}: Props) {
    const [isLoading, setLoading] = useState(true);
    
    return (
        <Image
            src={imageUrl}
            alt='image'
            priority
            className={`
                object-cover
                group-hover:opacity-75
                duration-700
                ease-in-out
                rounded-lg
                ${isLoading ? 'grayscale blur-2xl scale-110' : 'grayscale-0 blur-0 scale-100'}
            `}
            sizes="100vw"
            style={{
                width: '600px',
                height: 'auto',
            }}
            width={500}
            height={300}
            onLoad={() => setLoading(false)}
        />
    )
}