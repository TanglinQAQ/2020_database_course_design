<template>
  <div>
    <!-- 路由占位符-->
    <router-view v-if="isRouterAlive">
    </router-view>
  </div>
</template>

<script>
export default {
  name: 'TeamMeet',
  provide() {
    return {
      reloadAll: this.reloadAll
    }
  },
  data() {
    return {
      isRouterAlive: true
    }
  },
  methods: {
    reloadAll() {
      this.isRouterAlive = false
      this.$nextTick(() => {
        this.isRouterAlive = true
      })
    }
  }
}
</script>

<style lang="less" scoped>
</style>