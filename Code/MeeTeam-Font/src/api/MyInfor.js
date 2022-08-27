import request from '@/utils/request'

export function GetUserInfor(params) {
    /*由用户id得到用户信息 */
    return request({
      url: '/Info/getInfo',
      method: 'get',
      params:{
        ID:params.user_id
      }
    })
  }
