//import React, { useEffect, useState, } from 'react';
import { useImmer, useImmerReducer } from 'use-immer';
import User from './Interfaces/User.ts'

function RegisterUser () {
    const [user, setUser] = useImmer<User>( {id: 0, user_name: '', email: ''});
    // useEffect(() => {
    //     addUser({userId: crypto.randomUUID(), userName: user.userName, email: user.email});
    // }, []);

    function handleNameChange(name: string) {
        setUser(draft => {
            draft.user_name = name;
        })
    }

    function handleEmailChange(email: string) {
        setUser(draft => {
            draft.email = email;
        })
    }
    

    return (
        <>
            <input value={user.user_name} placeholder={'username'} onChange={e => {handleNameChange(e.target.value)}} />
            <input value={user.email} placeholder={'Enter your email'} onChange={e => {handleEmailChange(e.target.value)}} />
            <button onClick={() => addUser(user)}>Submit</button>
        </>
    )
}

async function addUser(user: User) : Promise<void> {
    await fetch('user', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            UserId: user.id,
            UserName: user.user_name,
            Email: user.email
        })
    }).then((Resp) => Resp.json())
        .then((Res) => console.log(Res))
}

export default RegisterUser;