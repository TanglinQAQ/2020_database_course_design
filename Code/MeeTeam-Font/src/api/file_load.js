import request from '@/utils/request'

export function openfile(params) {
    return request({
        url: '/File/OpenFile',
        method: 'get',
        params: {
            target: params.target,
            id: params.id
        }
    })
}