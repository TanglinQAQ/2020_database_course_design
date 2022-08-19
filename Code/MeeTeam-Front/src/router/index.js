import Vue from 'vue'
import Router from 'vue-router'


Vue.use(Router)

//导入需要的组件
//账号操作相关

import CreatList from '@/view/CreatList.vue'
import AddUser from '@/view/AddUser.vue'
import ChangeList from '@/view/ChangeList.vue'
import UserInformation from '@/view/UserInformation.vue'
import LogOut from '@/view/Logout.vue'
import PostInfor from '@/view/PostInfor.vue'
import PersonInfo from '@/view/PersonInfo.vue'
import LogIn from '@/view/Login.vue'
//主页
import AdminPage from '@/view/MainPage/AdminPage.vue'
import UserPage from '@/view/MainPage/UserPage.vue'
//通知相关
import NoticeList from '@/view/Notice/NoticeList.vue'
import ShowNotice from '@/view/Notice/ShowNotice.vue'
import CreateNotice from '@/view/Notice/CreateNotice.vue'
import User_NoticeList from '@/view/Notice/User_NoticeList.vue'
import User_ShowNotice from '@/view/Notice/User_ShowNotice.vue'
//项目需求相关
import MyProject from '@/view/Project_and_Require/MyProject.vue'
import ProjectDetail from '@/view/Project_and_Require/ProjectDetail.vue'
import InforList from '@/view/Project_and_Require/InforList.vue'
export default new Router({
    //在这里声明路由规则
    routes: [
        { path: '/', redirect: '/login' },
        { path: '/login', component: LogIn },
        { path: '/users/LogOut', component: LogOut },
        { path: '/users/PostInfor', component: PostInfor },
        { path: '/users/PersonInfo', component: PersonInfo },
        { path: '/users/CreatList', component: CreatList },
        { path: '/users/ChangeList', name: 'ChangeList', component: ChangeList, props: true },
        { path: '/users/AddUser', component: AddUser },
        {
            path: '/users/UserInformation', name: 'UserInformation', component: UserInformation, props: true, meta: {
                keepAlive: true
            }
        },
        //管理员主页及其子页面
        {
            path: '/Admin/AdminPage', component: AdminPage,
            children: [
                { path: '/Admin/NoticeList', component: NoticeList },
                { path: '/Admin/CreateNotice', component: CreateNotice },
                { path: '/Admin/ShowNotice', component: ShowNotice }
            ], props: true
        },
        //用户主页及其子页面
        {
            path: '/users/UserPage', component: UserPage,
            children: [
                { path: '/users/NoticeList', component: User_NoticeList },
                { path: '/users/User_ShowNotice', component: User_ShowNotice },
                { path: '/users/InforList', component: InforList },
                { path: '/users/MyProject', component: MyProject },
                { path: '/users/ProjectDetail', component: ProjectDetail }
            ], props: true
        }
    ]
}
)