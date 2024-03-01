import {useEffect, useState, } from 'react';
import User from './Interfaces/User.ts'

function UserList() {
    const [users, setUsers] = useState<User[]>([]);
    async function getUsers(): Promise<User[]> {
        const response = await fetch('user');
        return response.json();
    }
    
    useEffect(() => {

        getUsers().then((resp) => {
            return setUsers(resp);
        })
        //throw new Error('oopsy doopsy');
    }, []);
    return (
        <></>
        // <div>
        //     {users.map((user) => (
        //         <div key={user.userId}>
        //             <h2>{user.userName}</h2>
        //             <p>{user.email}</p>
        //         </div>
        //     ))}
        // </div>
    );
}


export default UserList;