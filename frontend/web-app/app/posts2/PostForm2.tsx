'use client'

import { Button, TextInput } from 'flowbite-react'
import React, { useState } from 'react'
import { FieldValues, useForm } from 'react-hook-form'
import Input2 from '../components/Input2';
import { useRouter } from 'next/navigation';
import { createPost } from '../actions/postActions';
import { PiNotePencil } from "react-icons/pi";

export default function PostForm2() {
    const router = useRouter();
    const {control, handleSubmit, 
        formState: {isSubmitting, isValid}} = useForm({
            mode:  'onTouched'
        });
    const [hideForm, setHideForm] = useState(true);

    async function onSubmit(data: FieldValues) {
        try {
            const res = await createPost(data);
            if (res.error) {
                throw res.error;
            }
            router.push(`/`)
            toggleForm();
        } catch (error: any) {
            console.log(error);
        }
    }

    function toggleForm() {
        setHideForm(hideForm => !hideForm)
    }

    return (
        <>
            <div className='flex flex-row'>
                <div 
                    onClick={toggleForm}
                    className='text-3xl'><PiNotePencil />
                </div>

                {!hideForm && <form className='flex flex-col mb-5' onSubmit={handleSubmit(onSubmit)}>


                    <div className='flex flex-row ml-7'>
                        <Input2 label='Content' name='content' control={control}
                            rules={{ required: 'Content is required' }} />
                        <Button 
                            isProcessing={isSubmitting}
                            disabled={!isValid}
                            type='submit'
                            color='success'
                            className='ml-2 px-3 mb-3 py-1'
                            size='base'
                            >Send</Button>
                    </div>
                    <div className='ml-7'>
                        <Input2 label='Image URL' name='imageUrl' control={control}
                            rules={{ required: 'Image URL is required' }} />
                    </div>
                </form>}
            </div>
        </>
  )
}
