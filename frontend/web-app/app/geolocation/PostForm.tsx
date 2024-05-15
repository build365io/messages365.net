'use client'

import { Button, TextInput } from 'flowbite-react'
import React from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import Input from '../components/Input';
import { useRouter } from 'next/navigation';
import { createPost } from '../actions/postActions';

type Props = {
    userLocation: { latitude: number; longitude: number; } | null
    onClick: () => void
}

export default function PostForm(props: Props) {
    const router = useRouter();
    const {control, register, handleSubmit, setFocus,
    formState: {isSubmitting, isValid, isDirty, errors}} = useForm();


    async function onSubmit(data: FieldValues) {
        try {
            data = {...data, content: props.userLocation?.latitude}
            console.log(data);
            const res = await createPost(data);
            if (res.error) {
                throw res.error;
            }
            router.push(`/posts2/details/${res.id}`)
        } catch (error: any) {
            console.log(error);
        }
    }

    return (
        <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
            <Input label='Title' name='title' control={control}
                rules={{ required: 'Tilte is required' }} />
            <div className='flex flex-row'>
                <img className="w-10 h-10 rounded-full mr-5" src="https://unsplash.com/photos/Y-rXBRdm3x0/download?ixid=M3wxMjA3fDB8MXxzZWFyY2h8MTI4fHxjaW5xdWUlMjB0ZXJyZXxlbnwwfHx8fDE3MDExMTQyMjl8MA&force=true" alt="Rounded avatar" />
                <Input label='Content' name='content' control={control} 
                    rules={{ required: 'Content is required' }} />
                
            </div>
            <Input label='Image URL' name='imageUrl' control={control}
                        rules={{ required: 'Image URL is required' }} />
            <div className="flex justify-between">
                <Button outline color='gray'>Cancel</Button>
                <Button 
                    isProcessing={isSubmitting}
                    disabled={!isValid}
                    type='submit'
                    outline color='success'>Submit</Button>
            </div>
        </form>
  )
}
