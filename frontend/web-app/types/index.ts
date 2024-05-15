export type PagedResult<T> = {
    results: T[]
    pageCount: number
    totalCount: number
}

export type Post = {
    title: string
    content: string
    imageUrl: string
    author: string
    createdAt: string
    updatedAt: string
    id: string
  }

export type Message = {    
    content: string    
    author: string
    createdAt: string    
    id: string
  }