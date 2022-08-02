import request from '@/utils/request'

export function deleteteam(params) {
    /*登陆 */
    return request({
      url: '/GroupRequirement/deleteGroupRequirement',
      method: 'delete',
      params:{
       
      }
    })
  }