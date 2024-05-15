'use client'

import { Button, TextInput } from 'flowbite-react'
import React from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import MessageInput from './MessageInput';
import { useRouter } from 'next/navigation';
import { createMessage } from '../actions/messageActions';

export default function MessageForm() {
    const router = useRouter();
    const {control, register, handleSubmit, setFocus,
    formState: {isSubmitting, isValid, isDirty, errors}} = useForm();
    
    async function onSubmit(data: FieldValues) {
        try {
            const res = await createMessage(data);
            if (res.error) {
                throw res.error;
            }
        } catch (error: any) {
            console.log(error);
        }
    }

    return (
    <form className='flex flex-col mt-3 max-w-80 bg-yellow-100' onSubmit={handleSubmit(onSubmit)}>
        <MessageInput label='Content' name='content' control={control}
            rules={{ required: 'Content is required' }} />

        <div className="flex">
            <Button 
                isProcessing={isSubmitting}
                disabled={!isValid}
                type='submit'
                outline color='success'>Submit</Button>
        </div>
    </form>
  )
}
