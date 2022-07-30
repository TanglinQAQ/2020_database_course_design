import request from '@/utils/request'

  export function login(params) {
    /*登陆 */
    return request({
      url: '/Login/login',
      method: 'get',
      params:{
        user_id:params.user,
        password:params.pass
      }
    })
  }