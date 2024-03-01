export default interface User {
    id?: number; //optional because the frontend doesn't care about the id when posting
    user_name: string;
    email: string;
}