import Vue from 'vue'
import Router from 'vue-router'


Vue.use(Router)

//导入需要的组件
import LogIn from '@/components/Login.vue'
import InforList from '@/components/InforList.vue'
import PostInfor from '@/components/PostInfor.vue'
import CreatList from '@/components/CreatList.vue'
import MyProject from '@/components/MyProject.vue'
import AddUser from '@/components/AddUser.vue'
import AdminPage from '@/view/AdminPage.vue'
import NoticeList from '@/view/NoticeList.vue'
import ShowNotice from '@/view/ShowNotice.vue'
import CreateNotice from '@/view/CreateNotice.vue'
export default new Router({
    //在这里声明路由规则
    routes: [
        {path: '/', redirect: '/login'},
        {path: '/login', component: LogIn},
        {path: '/users/InforList', component: InforList},
        {path: '/users/PostInfor', component: PostInfor},
        {path: '/users/CreatList', component: CreatList},
        {path: '/users/MyProject',component:MyProject},
        {path: '/users/AddUser',component:AddUser},
        { path: '/Admin/AdminPage', component: AdminPage },
        { path: '/Admin/NoticeList', component: NoticeList },
        {path: '/Admin/ShowNotice',component:ShowNotice,meta:{keepAlive:false}},
        {path: '/Admin/CreateNotice', component:CreateNotice},
    ],
})