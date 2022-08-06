import request from '@/utils/request'

export function deleteteam(params) {
    /*登陆 */
    return request({
      url: '/GroupRequirement/deleteGroupRequirement',
      method: 'delete',
      params:{
        require_id:params.require_id
       //还没写要传入给数据库的数据
      }
    })
  }
