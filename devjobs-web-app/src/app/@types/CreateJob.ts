export interface CreateJob {
    companyId: string,
    position: string,
    contractType: string,
    location: string,
    description: string,
    requirements: {
        content: string,
        items: string[]
    },
    roles: {
        content: string,
        items: string[]
    }
}
