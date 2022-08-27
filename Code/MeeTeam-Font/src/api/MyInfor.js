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
  export function GetMyCollection(params) {
    /*得到我的收藏 */
    return request({
      url: '/Facorite/GetFacorite',
      method: 'get',
      params:{
        user_id:params.user_id
      }
    })
  }
  export function AddMyCollection(params) {
    /*添加收藏 */
    return request({
      url: '/Facorite/AddFacorite',
      method: 'post',
      params:{
        facorite_id:params.facorite_id,
        owner_id:params.owner_id,
        project_id:params.project_id,
      }
    })
  }
  export function SelectAllCollection() {
    /*查询所有收藏*/
    return request({
      url: '/Facorite/SelectAllFacorite',
      method: 'get',
    })
  }