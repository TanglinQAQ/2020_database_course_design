import request from '@/utils/request'

export function addviewhistory(params){
    return request({
        url: '/User/AddViewHistory',
        method: 'post',
        params: {
            require_id: params.require_id
        }
    })

}