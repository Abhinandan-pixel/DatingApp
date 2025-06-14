import { Photo } from "./Photo"


export interface Member {
    id: number
    userName: string
    photoUrl: string
    age: number
    knownAs: string
    created: string
    lastActive: string
    gender: string
    introduction: string
    interests: string
    city: string
    country: string
    photos: Photo[]
}


