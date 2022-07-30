import request from '@/utils/request'

  export function login(params) {
    /*登陆 */
    return request({
      url: '/Login/login',
      method: 'get',
      params:{
        ID:params.user,
        Word:params.pass
      }
    })
  }